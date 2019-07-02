import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {Memoryinfo} from '../../models/memoryinfo';

@Component({
  selector: 'app-smsettings',
  templateUrl: './smsettings.component.html',
  styleUrls: ['./smsettings.component.css']
})
export class SmsettingsComponent implements OnInit {

  settingsGroup: FormGroup;
  memoryinfo: Memoryinfo;


  constructor() { }

  ngOnInit() {
    this.settingsGroup = new FormGroup({
      'newwords': new FormControl(0),
      'minutes': new FormControl(40)
    });
  }

  onSubmit() {

  }

}
