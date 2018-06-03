import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {VariantItem} from '../../models/variantitem';

@Component({
  selector: 'app-leveltasklist',
  templateUrl: './leveltasklist.component.html',
  styleUrls: ['./leveltasklist.component.css']
})
export class LeveltasklistComponent implements OnInit, OnChanges {

  @Input() variants: VariantItem[];
  @Output() selected = new EventEmitter<boolean>() ;

  selectedItem: VariantItem;
  isPreview: boolean;

  constructor() { }

  ngOnInit() {
    this.initialize();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.variants != null) {
      this.initialize();
    }
  }


  onSelect(event, item) {
    if (this.selectedItem == null) {
      this.selectedItem = item;
      this.selected.emit(this.selectedItem.iscorrect);
    }
  }

  private initialize(): void {
    this.selectedItem = null;
    this.isPreview = false;
  }


}
