import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule, MatSelectModule, MatTabsModule} from '@angular/material/';
import { DxDataGridModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { PatientComponent } from './patient/patient.component';
import { PatientService } from './_services/patient.service';




@NgModule({
   declarations: [
      AppComponent,
      PatientComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
      MatButtonModule,
      MatCardModule,
      MatInputModule,
      MatRadioModule,
      MatDatepickerModule,
      MatNativeDateModule,
      MatSelectModule,
      DxDataGridModule,
      MatTabsModule
   ],
   providers: [
      PatientService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
