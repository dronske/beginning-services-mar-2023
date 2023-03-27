import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { FormDataType, LocationCreate } from '../../models'
import { locationEvents } from '../../state/actions/location.actions';
@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css']
})
export class EntryComponent {
  form = new FormGroup<FormDataType<LocationCreate>>({
    name: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required, Validators.maxLength(75)
      ]
    }),
    description: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required, Validators.maxLength(1000)
      ]
    })
  })

  get name() {return this.form.controls.name;}
  get description() { return this.form.controls.description;}
constructor(private readonly store:Store) {}
  submit(foci:HTMLInputElement) {
    if(this.form.valid) {
      const payload = this.form.value as LocationCreate;
      this.store.dispatch(locationEvents.locationCreated({payload}));
      this.form.reset();
      foci.focus();
    } else {
     this.form.markAllAsTouched();
    }
  }
}
