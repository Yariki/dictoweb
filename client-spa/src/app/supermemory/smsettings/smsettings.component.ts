import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {Memoryinfo} from '../../models/memoryinfo';
import {MemoryService} from '../../services/memory.service';
import {ActivatedRoute, Router} from '@angular/router';
import {RepeatingsettingsService} from '../../services/repeatingsettings.service';

@Component({
  selector: 'app-smsettings',
  templateUrl: './smsettings.component.html',
  styleUrls: ['./smsettings.component.css']
})
export class SmsettingsComponent implements OnInit {

  settingsGroup: FormGroup;
  memoryinfo: Memoryinfo;


  constructor(private memoryService: MemoryService,  private router: Router, private activeRoute: ActivatedRoute, private repeatingsettingsService: RepeatingsettingsService ) {
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
    this.repeatingsettingsService.minutes = +this.settingsGroup.value['minutes'];
    this.repeatingsettingsService.newwords = +this.settingsGroup.value['newwords'];

    this.router.navigate(['repeat'], {relativeTo: this.activeRoute  });
  }

}
