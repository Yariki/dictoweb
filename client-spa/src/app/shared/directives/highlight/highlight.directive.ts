import {Directive, ElementRef, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {Levenshtein} from 'levenshtein';


@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective implements  OnInit {

  constructor(private el: ElementRef) {
    console.log(el.nativeElement.value);
  }

  private distance = 75;

  @Input() template: string;

  @Input() text: string;

  ngOnInit(): void {
    if (this.template == null) {
      return;
    }

    const regex = /(\w+)/g;

    let matches = [];
    let result;
    while ((result = regex.exec(this.text)) !== null) {

      const currentDistance = this.levenshtein(result[0], this.template);
      if (currentDistance < 4) {
        matches.push(result);
      }
    }

    let temp = this.text;
    let text = '';
    let startIndex = 0;
    if (matches.length > 0) {
      for (let i = 0; i < matches.length; i++) {
        const match = matches[i];
        const part = startIndex < match.index ? temp.substring(startIndex, match.index) : '';
        text += part + ' ' + "<span style='background: yellow'>" + match[0] + '</span>' + ' ';
        startIndex = (match.index + match[0].length) + 1;
      }
    }
    if ( startIndex < this.text.length ) {
      const part = temp.substr(startIndex, this.text.length - 1);
      text += part;
    }
    this.el.nativeElement.innerHTML = text;
  }

  private  levenshtein(a, b) {
    let t = [], u, i, j;
    const m = a.length, n = b.length;
    if (!m) { return n; }
    if (!n) { return m; }

    for (j = 0; j <= n; j++) { t[j] = j; }

    for (i = 1; i <= m; i++) {
      for (u = [i], j = 1; j <= n; j++) {
        u[j] = a[i - 1] === b[j - 1] ? t[j - 1] : Math.min(t[j - 1], t[j], u[j - 1]) + 1;
      } t = u;
    }

    return u[n];
  }




}
