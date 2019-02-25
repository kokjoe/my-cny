import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {
   MatNativeDateModule,
   MatSelectModule,
   MatTabsModule,
   MatSidenavModule,
   MatToolbarModule,
   MatIconModule,
   MatListModule,
   MatMenuModule,
   MatAutocompleteModule,
   MatSnackBarModule
} from '@angular/material/';
import { RouterModule } from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { DxDataGridModule } from 'devextreme-angular';
import { AppComponent } from './app.component';
import { PatientComponent } from './patient/patient.component';
import { PatientService } from './_services/patient.service';
import { VisitComponent } from './visit/visit.component';
// import { routing } from './routes';


@NgModule({
   declarations: [
      AppComponent,
      PatientComponent,
      VisitComponent
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
      MatSidenavModule,
      MatToolbarModule,
      MatIconModule,
      MatListModule,
      MatMenuModule,
      MatAutocompleteModule,
      MatSnackBarModule,
      DxDataGridModule,
      MatTabsModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule,
      // routing
   ],
   providers: [
      PatientService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
