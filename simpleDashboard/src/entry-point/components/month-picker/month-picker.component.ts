import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-month-picker',
  templateUrl: './month-picker.component.html',
  styleUrls: ['./month-picker.component.css']
})
export class MonthPickerComponent implements OnInit {
  private backPng = 'images/back.png';
  private forwardPng = 'images/forward.png';

  constructor() { }

  ngOnInit() {
  }

}
