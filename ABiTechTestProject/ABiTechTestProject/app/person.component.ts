import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { IPerson } from './models/Models';   


@Component({
    selector: 'person-list',
    templateUrl: '/app/templates/person-list.html'
})

export class PersonComponent implements OnInit {

    personList: Array<IPerson> = [];

    newPerson: IPerson = {
        Id: null,
        FirstName: "",
        SurName: "",
        BirthDay: null,
        Email: ""
    };

    selectedPerson: IPerson = {
        Id: null,
        FirstName: "",
        SurName: "",
        BirthDay: null,
        Email: ""
    };

    constructor(private http: Http) {
    }

    ngOnInit() {
        
        this.http.get('/api/PersonAPI').subscribe(data => {
            this.personList = JSON.parse(data['_body']);
        });
    }

    setActivePerson(person: IPerson): void {
        this.selectedPerson = person;
    }

    createPerson(): void {
        this.http.post('/api/PersonAPI/Create', this.newPerson).subscribe(data => {
            this.personList.push(JSON.parse(data['_body']));

            this.newPerson.FirstName = '';
            this.newPerson.SurName = '';
            this.newPerson.BirthDay = null;
            this.newPerson.Email = '';
        });
    }

    deletePerson(model: IPerson): void {
        this.http.delete('/api/PersonAPI/Delete/' + model.Id).subscribe((res) => {
            var index = this.personList.indexOf(model, 0);
            if (index > -1) {
                this.personList.splice(index, 1);
                console.log("delete");
            }
        });
    }

    updatePerson(model: IPerson): void {
        let data = {
            Email: model.Email
        };
        this.http.put('/api/PersonAPI/Update/', data).subscribe((res) => {
            let data = JSON.parse(res['_body']) as IPerson;

            var index = this.personList.indexOf(model, 0);
            if (index > -1) {
                this.personList.splice(index, 1, data);

                console.log("update")
            }
        });
    }
}