import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { PersonComponent } from './person.component'

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],
    declarations: [PersonComponent],
    bootstrap: [PersonComponent]
})
export class PersonModule { }