import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DayManagementComponent } from './day-management.component';

describe('DayManagementComponent', () => {
  let component: DayManagementComponent;
  let fixture: ComponentFixture<DayManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DayManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DayManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
