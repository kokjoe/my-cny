import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

    constructor(private alert: MatSnackBar) {}

    openAlert(message: string, action: string) {
        this.alert.open(message, action, {duration: 4000});
    }

}
