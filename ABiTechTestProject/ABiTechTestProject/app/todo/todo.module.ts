import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { TodoComponent } from './todo.component'

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],
    declarations: [TodoComponent],
    bootstrap: [TodoComponent]
})
export class TodoModule { }