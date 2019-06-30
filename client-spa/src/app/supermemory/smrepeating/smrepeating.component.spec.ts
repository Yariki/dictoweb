import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmrepeatingComponent } from './smrepeating.component';

describe('SmrepeatingComponent', () => {
  let component: SmrepeatingComponent;
  let fixture: ComponentFixture<SmrepeatingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmrepeatingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmrepeatingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
