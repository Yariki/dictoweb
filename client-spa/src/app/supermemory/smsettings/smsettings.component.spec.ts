import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmsettingsComponent } from './smsettings.component';

describe('SmsettingsComponent', () => {
  let component: SmsettingsComponent;
  let fixture: ComponentFixture<SmsettingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmsettingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmsettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
