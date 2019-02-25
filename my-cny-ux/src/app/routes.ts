import { Routes, RouterModule } from '@angular/router';
import { PatientComponent } from './patient/patient.component';
import { ModuleWithProviders } from '@angular/core';
import { VisitComponent } from './visit/visit.component';

export const appRoutes: Routes = [
    {path: '', redirectTo: 'patient', pathMatch: 'full'},
    {path: 'patient', component: PatientComponent},
    {path: 'visit', component: VisitComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
