import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'app-com',
    template: `
        <div>
                  <nav class='navbar navbar-inverse'>
                       <div class='container-fluid'>
                         <ul class='nav navbar-nav'>
                           <li><a [routerLink]="['todo']">Todo</a></li>
                            <li><a [routerLink]="['person']">Person</a></li>
                      </ul>
                      </div>
                 </nav>    
              <div class='container'>
                <router-outlet></router-outlet>
              </div>
             </div>     
    `
})

export class AppComponent{
       
}