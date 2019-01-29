import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class PatientService {
    baseUrl = environment.apiUrl;
    patients: any;

    constructor(private http: HttpClient) { }

    getPatients() {
        return this.http.get(this.baseUrl + 'patients');
    }

    // savePatients(patient: Patient) {
    //     return this.http.post(this.baseUrl + 'patients', patient);
    // }

    // saveEContact(econtact: EmergencyContact) {
    //     return this.http.post(this.baseUrl + 'emer', econtact);
    // }

}
