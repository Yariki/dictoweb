import {Component, Input, OnInit} from '@angular/core';
import {VariantItem} from '../../models/variantitem';

@Component({
  selector: 'app-leveltasklist',
  templateUrl: './leveltasklist.component.html',
  styleUrls: ['./leveltasklist.component.css']
})
export class LeveltasklistComponent implements OnInit {

  @Input() variants: VariantItem[];
  selectedItem: VariantItem;
  isPreview: boolean;

  constructor() { }

  ngOnInit() {
  }


  onSelect(event, item) {
    this.selectedItem = item;
  }


}
