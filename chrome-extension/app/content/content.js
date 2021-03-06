// Popup code has been got from extension => https://add0n.com/google-translator.html



// mediator.receive('test',function (data) {
//     debugger;
//     console.log(data);
// });
//
// var mediator = (function(){
//
//     return {
//         send: function(request){
//             chrome.runtime.sendMessage(request);
//         },
//         receive: function(id, callback){
//             chrome.runtime.onMessage.addListener(function (request, sender, sedResponse) {
//                 debugger;
//                 if(reque.path == MessagesDirections.BackgroundToContent && request.method == id){
//                     callback(request.data);
//                 }
//             });
//         }
//     }
// })();

function init() {
    /* Global Variables */
    var translateIconShow = 0;
    var translateIconTime = 3;
    var word, definition, keyCode;
    var translateInputArea = true;
    var isTextSelection    = true;
    var isDblclick         = true;
    var isTranslateIcon    = true;
    var minimumNumberOfCharacters = 2;
    var isMouseOverTranslation = false;
    var allowMouseOverTranslation = true;
    var bubbleRGB = "rgb(222, 184, 135)";
    var bubble, header, content, footer, bookmarks, voice, home, settings, faq, addBtn, soundButton;
    var currentTranslation;

    console.log('content is loaded...');


    function html(tag, attrs, parent) {
        if (!attrs) attrs = {};
        var elm = document.createElement(tag);
        for (var i in attrs) {
            elm.setAttribute(i, attrs[i]);
        }
        if (parent) parent.appendChild(elm);
        return elm;
    }

    function dir(e) {
        var wGCS = window.getComputedStyle(e, null);
        if (wGCS) {
            var text_direction = wGCS.direction || '';
            if (text_direction == 'rtl') e.style.textAlign = "right";
            if (text_direction == 'ltr') e.style.textAlign = "left";
        }
    }

    function getSelectedRect(w) {
        try {
            if (w.rangeCount) {
                var range = w.getRangeAt(0).cloneRange();
                if (range.startOffset !== range.endOffset) {
                    var rect = range.getBoundingClientRect();
                    return rect;
                }
                else if (range.startOffset == 0 && range.endOffset == 0) {
                    return null;
                }
                else {
                    var arr = range.startContainer.childNodes;
                    for (var i = 0; i < arr.length; i++) {
                        var target = arr[i].nodeName.toLowerCase();
                        if (target.indexOf('text') !== -1 || target.indexOf('input') !== -1) {
                            var rect = getTextBoundingRect(arr[i], arr[i].selectionStart, arr[i].selectionEnd);
                            if (rect.top && rect.left && rect.height && rect.width) {
                                return rect;
                            }
                            else {
                                return null;
                            }
                        }
                    }
                    range.collapse(false);
                    var dummy = document.createElement("span");
                    range.insertNode(dummy);
                    var rect = dummy.getBoundingClientRect();
                    dummy.parentNode.removeChild(dummy);
                    return rect;
                }
            }
            else {
                return null;
            }
        }
        catch (e) {
            return null;
        }
    }

    function requestBubbleTranslation(e) {
        header.textContent = '';
        content.textContent = '';
        translateIcon.style.display = 'none';
        var rect = requestBubbleTranslation.rect;
        if (rect && rect.top) mainDIV.style.top = (rect.top + window.scrollY + rect.height) + 'px';
        else mainDIV.style.top = (e.clientY + window.scrollY + 40) + 'px';
        if (rect && rect.left) mainDIV.style.left = (rect.left + window.scrollX - 23 + rect.width / 2) + 'px';
        else mainDIV.style.left = (e.clientX + window.scrollX - 40)  + 'px';
        mainDIV.style.width = (274) + "px";
        mainDIV.style.height = (80) + "px";
        mainDIV.style.display = 'block';
        header.style.width = (264) + "px";
        header.parentNode.style.backgroundImage = "url(" + manifest.url + "data/icons/loading.gif)";
        content.style.display = "none";
        allowMouseOverTranslation = false;

        // translate word
        console.log('Need to translate: ' +  requestBubbleTranslation.text);

        chrome.runtime.sendMessage(new Message(Messages.translate,requestBubbleTranslation.text),function(data){
            processTranslatedWord(data)
        });
        // httpService.translate(requestBubbleTranslation.text,null,function(data){
        //     processTranslatedWord(data)
        // });

    }

    var timeoutIconShow, timeoutIconHide;
    function showTranslateIcon(e) {
        var rect = requestBubbleTranslation.rect;
        if (rect && rect.top) translateIcon.style.top = (rect.top + window.scrollY - 18) + 'px';
        else translateIcon.style.top = (e.clientY + window.scrollY - 30) + 'px';
        if (rect && rect.left) translateIcon.style.left = (rect.left + window.scrollX + rect.width - 2) + 'px';
        else translateIcon.style.left = (e.clientX + window.scrollX + 10)  + 'px';
        if (timeoutIconShow) window.clearTimeout(timeoutIconShow);
        if (timeoutIconHide) window.clearTimeout(timeoutIconHide);
        timeoutIconShow = window.setTimeout(function () {
            translateIcon.style.display = "block";
        }, translateIconShow * 1000); /* show TranslateIcon with delay */
        timeoutIconHide = window.setTimeout(function () {
            translateIcon.style.display = "none";
        }, translateIconTime * 1000); /* hide TranslateIcon automatically */
    }

    /* mainDIV is to make the bubble draggable */
    var mainDIV = html("div", {"class": "igtranslator-main-div"}, document.body);
    var iFrame = html("iframe", {
        src: "about:blank",
        "class": "igtranslator-iframe",
        scrolling: "no",
        frameborder: 0
    }, mainDIV);

    window.setTimeout(function () { /* wait to load iframe */
        if (iFrame.contentDocument) {
            var cssLink = html("link", {
                href: manifest.url + "data/content/content.css",
                rel: "stylesheet",
                type: "text/css"
            }, iFrame.contentDocument.head);
            /* Bubble */
            bubble = html("table", {
                "class": "igtranslator-bubble"
            }, iFrame.contentDocument.body);
            /* Header */
            header = html("pre", {dir: "auto"}, html("td", {
                colspan: 5,
                "class": "igtranslator-header"
            }, html("tr", {}, bubble)));
            /* Content */
            content = html("tbody", {
                "class": "igtranslator-content"
            }, html("table", {}, html("td", {colspan: 5}, html("tr", {}, bubble))));
            /* Footer */
            footer = html("tr", {
                "class": "igtranslator-footer",
            }, bubble);

            addBtn = html("td",{
                style: "background-image: url(" + chrome.runtime.getURL("data/icons/add.png") + ")",
                    title: "Add new word"
            },footer);
            addBtn.addEventListener("click",function(){

                if(currentTranslation  && currentTranslation.isexisting){
                    return;
                }

                if(currentTranslation){

                    chrome.runtime.sendMessage(new Message(Messages.addword,currentTranslation),function (result) {
                        currentTranslation.isexisting = result.data.status == 200;
                        addBtn.style.backgroundImage = "url(" + chrome.runtime.getURL("data/icons/" + (!currentTranslation.isexisting ? "" : "no") +"add.png") + ")";
                    });
                    // httpService.addWord(currentTranslation,function (result) {
                    //     currentTranslation.isexisting = result.data.status == 200;
                    //     addBtn.style.backgroundImage = "url(" + chrome.runtime.getURL("data/icons/" + (!currentTranslation.isexisting ? "" : "no") +"add.png") + ")";
                    // })
                }
            });

            soundButton = html("td",{style: "background-image: url(" + chrome.runtime.getURL("data/icons/voice.png") + ")"},footer);

            soundButton.addEventListener("click",function(){
                if(currentTranslation && currentTranslation.urlsound != null && currentTranslation.urlsound != undefined){
                    var audio = new Audio(currentTranslation.urlsound);
                    audio.play();
                }
            });

        }
        /* addEventListener for resize */
        if (iFrame.contentWindow) {
            iFrame.contentWindow.addEventListener("resize", function (e) {
                var mainDIVStyle = window.getComputedStyle(mainDIV, null);
                if (mainDIVStyle) {
                    var mainDIVH = mainDIVStyle.getPropertyValue("height");
                    if (mainDIVH && mainDIVH !== "auto") {
                        content.style.height = parseInt(mainDIVH) - 80 + "px";
                    }
                }
            });
        }
    }, 500);

    /* color setup */
    var colorLevel0 = '', colorLevel1 = '', colorLevel2 = '';
    function colorBubble() {
        function shadeRGBColor(color, percent) {
            var f = color.split(","), t = percent < 0 ? 0 : 255, p = percent < 0 ? percent * -1 : percent, R = parseInt(f[0].slice(4)), G = parseInt(f[1]), B = parseInt(f[2]);
            return "rgb(" + (Math.round((t - R) * p) + R) + "," + (Math.round((t - G) * p) + G) + ","+(Math.round((t - B) * p) + B) + ")";
        }
        /* percent 0 is for dark and 100 is for light */
        colorLevel0 = shadeRGBColor(bubbleRGB, 0.00);
        colorLevel1 = shadeRGBColor(bubbleRGB, 0.30);
        colorLevel2 = shadeRGBColor(bubbleRGB, 0.60);

        /* color inside iframe */
        var doc = iFrame.contentDocument;
        if (doc) {
            var id = "igtranslator-color";
            var style = doc.getElementById(id);
            if (style) style.parentNode.removeChild(style);
            var style = doc.createElement("style");
            style.setAttribute("type", "text/css");
            style.setAttribute("id", id);
            var head = doc.querySelector("head") || doc.head || doc.documentElement;
            if (head) head.appendChild(style);
            style.sheet.insertRule(".igtranslator-bubble {background-color: " + colorLevel2 + "; border: solid 1px " + colorLevel0 + ";}", 0);
            style.sheet.insertRule(".igtranslator-bubble:before {border-bottom-color: " + colorLevel0 + " !important;}", 1);
            style.sheet.insertRule(".igtranslator-bubble:after {border-bottom-color: " + colorLevel2 + " !important;}", 2);
            style.sheet.insertRule(".igtranslator-content {border-top: solid 1px " + colorLevel0 + ";}", 3);
            style.sheet.insertRule(".igtranslator-footer td {background-color: " + colorLevel1 + "; border: solid 1px " + colorLevel0 + ";}", 4);
            style.sheet.insertRule(".igtranslator-footer td:hover {background-color: " + colorLevel0 + ";}", 5);
        }
        /* color inside document */
        var style = document.getElementById(id);
        if (style) style.parentNode.removeChild(style);
        var style = document.createElement("style");
        style.setAttribute("type", "text/css");
        style.setAttribute("id", id);
        var head = document.querySelector("head") || document.head || document.documentElement;
        if (head) head.appendChild(style);
        style.sheet.insertRule(".igtranslator-activator-icon {background-color: " + colorLevel0 + " !important;}", 0);
    }
    colorBubble();

    /* Translate Icon */
    var translateIcon = html("div", {
        "class": "igtranslator-activator-icon bounceIn",
        style: "background-image: url(" + manifest.url + "data/icons/home.png)",
        title: "Click to Show Translation"
    }, document.body);
    translateIcon.addEventListener("click", requestBubbleTranslation, false);

    var smoothScroll = {};
    function hideBubble(e) {
        var target = e.target || e.originalTarget;
        while (target.parentNode && target.getAttribute) {
            if (target == bubble || target == translateIcon || target == iFrame || target == mainDIV) {
                return; /* Do not hide the panel when user clicks inside the panel */
            }
            target = target.parentNode;
        }
        translateIcon.style.display = 'none';
        mainDIV.style.display = 'none';
        mainDIV.style.width = (0) + "px";
        mainDIV.style.height = (0) + "px";
        if (smoothScroll.scrollTo) {
            window.scrollTo(smoothScroll.scrollX, smoothScroll.scrollY);
            smoothScroll = {
                scrollTo: false,
                windowScrollX: 0,
                windowScrollY: 0
            };
        }
    }
    document.addEventListener('mousedown', hideBubble, false);
    document.addEventListener('keydown', function (e) {
        keyCode = e.keyCode;
        if (!e.metaKey && !e.altKey && keyCode != 45 && keyCode != 84) {
            hideBubble(e);
        }
    }, false);

    document.addEventListener('keyup', function (e) {
        keyCode = null;
    }, false);

    function getSelectedText(target) {
        function getTextSelection() {
            var selectedText = '';
            if (target.getAttribute("type")) {
                if (target.getAttribute("type").toLowerCase() == "checkbox") {
                    return '';
                }
            }
            var value = target.value;
            if (value) {
                var startPos = target.selectionStart;
                var endPos = target.selectionEnd;
                if (!isNaN(startPos) && !isNaN(endPos)) selectedText = value.substring(startPos, endPos);
                return selectedText;
            }
            else return '';
        }
        var selectedText = window.getSelection().toString();
        if (!selectedText) selectedText = getTextSelection();
        return selectedText;
    }

    function getWordAtPoint(elem, x, y) {
        if (elem && elem.nodeType == elem.TEXT_NODE) {
            var range = elem.ownerDocument.createRange();
            range.selectNodeContents(elem);
            var currentPos = 0;
            var endPos = range.endOffset;
            while(currentPos + 1 < endPos) {
                range.setStart(elem, currentPos);
                range.setEnd(elem, currentPos+1);
                if(range.getBoundingClientRect().left <= x && range.getBoundingClientRect().right  >= x &&
                    range.getBoundingClientRect().top  <= y && range.getBoundingClientRect().bottom >= y) {
                    range.expand("word");
                    var originalRange = range;
                    range.detach();
                    return (originalRange);
                }
                currentPos += 1;
            }
        } else {
            for(var i = 0; i < elem.childNodes.length; i++) {
                var range = elem.childNodes[i].ownerDocument.createRange();
                range.selectNodeContents(elem.childNodes[i]);
                if(range.getBoundingClientRect().left <= x && range.getBoundingClientRect().right  >= x &&
                    range.getBoundingClientRect().top  <= y && range.getBoundingClientRect().bottom >= y) {
                    range.detach();
                    return (getWordAtPoint(elem.childNodes[i], x, y));
                }
                else {
                    range.detach();
                }
            }
        }
        return (null);
    }

    function triggerTranslation(e) {
        var target = e.target || e.originalTarget;

        /* detect input or editable areas */
        var flag1 = (target.localName == "input" || target.localName == "textarea");
        var flag2 = (target.getAttribute('contenteditable') == 'true');
        var flag3 = (target.className.indexOf("editable") != -1);
        var inputArea = flag1 || flag2 || flag3;
        if (inputArea && !translateInputArea) return;

        var keyboard = e.metaKey || e.altKey || keyCode == 45 || keyCode == 84;
        var dblclick = (e.type == 'dblclick') && isDblclick;
        var mouseup = (e.type == 'mouseup') && isTextSelection;// && keyboard;

        if (false) {
            var range = getWordAtPoint(e.target, e.x, e.y);
            if (range) {
                var selectedText = range.toString();
                requestBubbleTranslation.text = selectedText;
                requestBubbleTranslation.rect = range.getBoundingClientRect();
                if (allowMouseOverTranslation) {
                    if (selectedText && selectedText.length >= minimumNumberOfCharacters) {
                        requestBubbleTranslation(e);
                    }
                }
            }
        }
        else { /* dblclick or mouseup translations */
            var selectedText = getSelectedText(target);
            if (selectedText && selectedText.length >= minimumNumberOfCharacters) {
                requestBubbleTranslation.text = selectedText;
                requestBubbleTranslation.rect = getSelectedRect(window.getSelection());
                requestBubbleTranslation.sentence = getSentence(target);
                if (isTranslateIcon && mainDIV.style.display == 'none') {
                    showTranslateIcon(e);
                }
                else if (dblclick || mouseup) {
                    requestBubbleTranslation(e);
                }
            }
        }
    }

    function getSentence(el){
        var re = window.getSelection();
        var result = '';
        var val = el.textContent;
        var start = re.baseOffset;
        var end =  re.extentOffset;
        if(val){
            while(val.charAt(start--) !== '.' && start >=0){}
            while(val.charAt(end++) !== '.' && end <= val.length){}
            start = start < 0 ? 0 : (start+2);

            result = val.substring(start,end);
        }
        return result;
    }

    function processTranslatedWord(data){
        mainDIV.style.width = "450px";
        mainDIV.style.height = "300px";

        if (typeof header === 'undefined') return
        header.parentNode.style.backgroundImage = "none";
        content.style.display = "block";
        if (data.status == StatusResult.Error) {
            header.textContent = data.message;
            header.style.width = "388px";
            header.style.textAlign = "center";
            content.style.backgroundImage = "url(" + manifest.url + "data/icons/error.png)";
            // voice.style.backgroundImage = "url(" + manifest.url + "data/icons/novoice.png)";
            // voice.setAttribute("isVoice", "no");
        } else if(data.status === StatusResult.TokenMissed){
            header.textContent = data.message;
            header.style.width = "388px";
            header.style.textAlign = "center";
            content.style.backgroundImage = "url(" + manifest.url + "data/icons/error.png)";
            // voice.style.backgroundImage = "url(" + manifest.url + "data/icons/novoice.png)";
        }
        else {

            currentTranslation = data.data;
            currentTranslation.sentence = requestBubbleTranslation.sentence;

            word = currentTranslation.original;
            definition = currentTranslation.phonetic;

            content.style.backgroundImage = "none";
            var isSound = currentTranslation.urlsound !== '' || currentTranslation.urlsound !== 'undefined';
            // voice.style.backgroundImage = "url(" + chrome.runtime.getURL("data/icons/" + (isSound ? "" : "no") + "voice.png")  +")";
            // voice.setAttribute("isVoice", isSound);

            addBtn.style.backgroundImage = "url(" + chrome.runtime.getURL("data/icons/" + (!currentTranslation.isexisting ? "" : "no") +"add.png") + ")";
            soundButton.disabled = currentTranslation.urlsound == null || currentTranslation.urlsound == undefined;

            var translated = currentTranslation.translate;
            if(!$.isEmptyObject(translated)){
                for (var item in translated){
                    var translations = translated[item];
                    if(translations && translations.length){
                        var pos = html('td',{
                            style: "color: #777; font-style: italic;"
                        }, html("tr", {}, content)).textContent = item;
                        var tr = html('tr',{class:""},content);
                        var translationsCell = html('td',{dir:'auto'},tr);
                        var ul = html('ul',{},translationsCell);
                        for(var translation in translations){
                            var li = html('li',{},ul);
                            li.textContent = translations[translation];
                        }
                        dir(translationsCell);
                    }
                }
            }else{
                var pos = html('td',{style:'font-style: bold;'},html('tr',{},content));
                pos.textContent = "There is no tranlation for word: " + word;
            }
        }
        /*
          smart-select width and height for the floating bubble;
          it is based on bubble and content width anf height;
          note: may still have some bugs.
        */
        var wGCSB = window.getComputedStyle(bubble, null);
        var wGCSC = window.getComputedStyle(content, null);
        if (wGCSB && wGCSC) {
            var mdWidth, mdHeight;
            var Wb = wGCSB.getPropertyValue("width");
            var Hb = wGCSB.getPropertyValue("height");
            var Wc = wGCSC.getPropertyValue("width");
            var Hc = wGCSC.getPropertyValue("height");
            if (Wb.indexOf("px") === -1 || !parseInt(Wb)) {
                if (Wc.indexOf("px") === -1 || !parseInt(Wc)) mdWidth = "auto";
                else mdWidth = parseInt(Wc) + 40 + "px";
            }
            else mdWidth = Wb;
            if (Hb.indexOf("px") === -1 || !parseInt(Hb)) {
                if (Hc.indexOf("px") === -1 || !parseInt(Hc)) mdHeight = "auto";
                else mdHeight = parseInt(Hc) + 80 + "px";
            }
            else mdHeight = Hb;
            if (Wb.indexOf("px") !== -1 && Wc.indexOf("px") !== -1) {
                if (parseInt(Wb) && parseInt(Wc)) {
                    if (parseInt(Wb) > (parseInt(Wc) + 50)) mdWidth = parseInt(Wc) + 40 + "px";
                }
            }
            if (Hb.indexOf("px") !== -1 && Hc.indexOf("px") !== -1) {
                if (parseInt(Hb) && parseInt(Hc)) {
                    if (parseInt(Hb) > (parseInt(Hc) + 90)) mdHeight = parseInt(Hc) + 80 + "px";
                }
            }
            // if (!onlyHeader) {
            //     extraWidth = 0;
            //     extraHeight = 100;
            //     if (parseInt(mdWidth) > 450) mdWidth = "450px";
            //     if (parseInt(mdWidth) < 300) mdWidth = "300px";
            //     if (parseInt(mdHeight) > 300) mdHeight = "300px";
            //     if (parseInt(mdHeight) < 80) mdHeight = "80px";
            // }
            // else {
            //     header.style.width = (parseInt(mdWidth) + extraWidth - 35) + "px";
            // }
            extraWidth = 0;
            extraHeight = 100;
            mainDIV.style.width = parseInt(mdWidth) + extraWidth + "px";
            mainDIV.style.height = parseInt(mdHeight) + extraHeight + "px";
            content.style.height = parseInt(mdHeight) - 80 + "px";

            function smoothScrollTo(duration) {
                var factor = 0, timer, start = Date.now();
                if (timer) window.clearInterval(timer);
                smoothScroll = {
                    scrollTo: true,
                    scrollX: window.scrollX,
                    scrollY: window.scrollY
                };
                function step() {
                    factor = (Date.now() - start) / duration;
                    var left = mainDIV.offsetLeft;
                    var width = mainDIV.offsetWidth;
                    window.scrollTo(window.scrollX + factor * parseInt(mdWidth), window.scrollY);
                    if (window.pageXOffset + window.innerWidth > left + width) {
                        window.clearInterval(timer);
                        factor = 1;
                        return;
                    }
                }
                timer = window.setInterval(step, 10);
            }
            if (!isMouseOverTranslation && mainDIV.offsetLeft > window.innerWidth - parseInt(mdWidth)) {
                smoothScrollTo(800);
            }
            allowMouseOverTranslation = true;
        }
    }

    /* adding listeners for mouseup and dblclick */
    document.addEventListener('mouseup', triggerTranslation, false);
    document.addEventListener('dblclick', triggerTranslation, false);

    /* removing EventListener */
    window.removeEventListener("DOMContentLoaded", init, false);
}

if (window.top === window) {
    window.addEventListener("DOMContentLoaded", init, false);
}

/*
  // Not active for now (imposing bugs)
  function initTimeout() {
    window.setTimeout(init, 3000);
    window.removeEventListener("load", initTimeout, false);
  }
  window.addEventListener("DOMContentLoaded", init, false);
  window.addEventListener("load", initTimeout, false);
*/

/* Get bounding rectangle for text or input area */
function getTextBoundingRect(input, selectionStart, selectionEnd, debug) {
    // @author Rob W         http://stackoverflow.com/users/938089/rob-w
    // @name                 getTextBoundingRect
    // @param input          Required HTMLElement with `value` attribute
    // @param selectionStart Optional number: Start offset. Default 0
    // @param selectionEnd   Optional number: End offset. Default selectionStart
    // @param debug          Optional boolean. If true, the created test layer will not be removed.

    // Basic parameter validation
    if (!input || !('value' in input)) return input;
    if (typeof selectionStart == "string") selectionStart = parseFloat(selectionStart);
    if (typeof selectionStart != "number" || isNaN(selectionStart)) {
        selectionStart = 0;
    }
    if (selectionStart < 0) selectionStart = 0;
    else selectionStart = Math.min(input.value.length, selectionStart);
    if (typeof selectionEnd == "string") selectionEnd = parseFloat(selectionEnd);
    if (typeof selectionEnd != "number" || isNaN(selectionEnd) || selectionEnd < selectionStart) {
        selectionEnd = selectionStart;
    }
    if (selectionEnd < 0) selectionEnd = 0;
    else selectionEnd = Math.min(input.value.length, selectionEnd);

    // If available (thus IE), use the createTextRange method
    if (typeof input.createTextRange == "function") {
        var range = input.createTextRange();
        range.collapse(true);
        range.moveStart('character', selectionStart);
        range.moveEnd('character', selectionEnd - selectionStart);
        return range.getBoundingClientRect();
    }
    // createTextRange is not supported, create a fake text range
    var offset = getInputOffset(),
        topPos = offset.top,
        leftPos = offset.left,
        width = getInputCSS('width', true),
        height = getInputCSS('height', true);

    // Styles to simulate a node in an input field
    var cssDefaultStyles = "white-space:pre;padding:0;margin:0;", listOfModifiers = ['direction', 'font-family', 'font-size', 'font-size-adjust', 'font-variant', 'font-weight', 'font-style', 'letter-spacing', 'line-height', 'text-align', 'text-indent', 'text-transform', 'word-wrap', 'word-spacing'];
    topPos += getInputCSS('padding-top', true);
    topPos += getInputCSS('border-top-width', true);
    leftPos += getInputCSS('padding-left', true);
    leftPos += getInputCSS('border-left-width', true);
    leftPos += 1; //Seems to be necessary

    for (var i=0; i < listOfModifiers.length; i++) {
        var property = listOfModifiers[i];
        cssDefaultStyles += property + ':' + getInputCSS(property) +';';
    }
    // End of CSS variable checks

    var text = input.value, textLen = text.length, fakeClone = document.createElement("div");
    if (selectionStart > 0) appendPart(0, selectionStart);
    var fakeRange = appendPart(selectionStart, selectionEnd);
    if (textLen > selectionEnd) appendPart(selectionEnd, textLen);

    // Styles to inherit the font styles of the element
    fakeClone.style.cssText = cssDefaultStyles;

    // Styles to position the text node at the desired position
    fakeClone.style.position = "absolute";
    fakeClone.style.top = topPos + "px";
    fakeClone.style.left = leftPos + "px";
    fakeClone.style.width = width + "px";
    fakeClone.style.height = height + "px";
    document.body.appendChild(fakeClone);
    var returnValue = fakeRange.getBoundingClientRect(); //Get rect

    if (!debug) fakeClone.parentNode.removeChild(fakeClone); //Remove temp
    return returnValue;

    // Local functions for readability of the previous code
    function appendPart(start, end){
        var span = document.createElement("span");
        span.style.cssText = cssDefaultStyles; //Force styles to prevent unexpected results
        span.textContent = text.substring(start, end);
        fakeClone.appendChild(span);
        return span;
    }
    // Computing offset position
    function getInputOffset(){
        var body = document.body, win = document.defaultView, docElem = document.documentElement, box = document.createElement('div');
        box.style.paddingLeft = box.style.width = "1px";
        body.appendChild(box);
        var isBoxModel = box.offsetWidth == 2;
        body.removeChild(box);
        box = input.getBoundingClientRect();
        var clientTop  = docElem.clientTop  || body.clientTop  || 0,
            clientLeft = docElem.clientLeft || body.clientLeft || 0,
            scrollTop  = win.pageYOffset || isBoxModel && docElem.scrollTop  || body.scrollTop,
            scrollLeft = win.pageXOffset || isBoxModel && docElem.scrollLeft || body.scrollLeft;
        return {
            top : box.top  + scrollTop  - clientTop,
            left: box.left + scrollLeft - clientLeft
        };
    }
    function getInputCSS(prop, isnumber) {
        var defaultView = document.defaultView;
        if (defaultView) {
            var dDGCS = defaultView.getComputedStyle(input, null);
            if (dDGCS) {
                var val = dDGCS.getPropertyValue(prop);
                return isnumber ? parseFloat(val) : val;
            }
        }
        return '';
    }
}
