import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { EntryPointComponent } from './entry-point/entry-point.component';
import { ToolsComponent } from './entry-point/components/tools/tools.component';
import { DashboardComponent } from './entry-point/components/dashboard/dashboard.component';
import { MonthPickerComponent } from './entry-point/components/month-picker/month-picker.component';
import { DayManagementComponent } from './entry-point/components/day-management/day-management.component';

@NgModule({
  declarations: [
    EntryPointComponent,
    ToolsComponent,
    DashboardComponent,
    MonthPickerComponent,
    DayManagementComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [EntryPointComponent]
})
export class AppModule { }
