import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {MemoryService} from '../../services/memory.service';
import {Params} from '@angular/router/src/shared';
import {Memoryinfo} from '../../models/memoryinfo';
import {Memoryrepeating} from '../../models/memoryrepeating';
import {RepeatingsettingsService} from '../../services/repeatingsettings.service';

@Component({
  selector: 'app-smrepeating',
  templateUrl: './smrepeating.component.html',
  styleUrls: ['./smrepeating.component.css']
})
export class SmrepeatingComponent implements OnInit {

  private repeatingTask: Memoryrepeating;

  constructor(private memoryService: MemoryService, private router: Router, private route: ActivatedRoute,
              private repeatingsettingsService: RepeatingsettingsService) { }

  ngOnInit() {
    this.initRepeating();
  }


  private initRepeating() {
    this.memoryService.getRepetition(
      {newwords: this.repeatingsettingsService.newwords, minutes: this.repeatingsettingsService.minutes}).then(value => {
      this.repeatingTask = value;
    });
  }

}
