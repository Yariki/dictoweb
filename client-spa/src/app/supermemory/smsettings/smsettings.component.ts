import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {Memoryinfo} from '../../models/memoryinfo';
import {MemoryService} from '../../services/memory.service';

@Component({
  selector: 'app-smsettings',
  templateUrl: './smsettings.component.html',
  styleUrls: ['./smsettings.component.css']
})
export class SmsettingsComponent implements OnInit {

  settingsGroup: FormGroup;
  memoryinfo: Memoryinfo;


  constructor(private memoryService: MemoryService ) {
    this.settingsGroup = new FormGroup({
      'newwords': new FormControl(0),
      'minutes': new FormControl(40)
    });
    this.memoryinfo = new Memoryinfo();
  }

  ngOnInit() {

    this.memoryService.getStatistic().then(value => {

      this.memoryinfo = value;

      this.settingsGroup = new FormGroup({
        'newwords': new FormControl(this.memoryinfo.newwords),
        'minutes': new FormControl(this.memoryinfo.minutes)
      });
    }).catch( reason => {
      console.log(reason);
    });
  }


  onSubmit() {

  }

}
