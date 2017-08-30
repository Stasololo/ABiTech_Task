import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { IStatus } from "../models/Models";


@Component({
    selector: 'status-list',
    templateUrl: '/app/templates/status-list.html'
})

export class StatusComponent implements OnInit {

    statusList: Array<IStatus> = [];

    newStatus: IStatus = {
        Id: null,
        Title: ""
    };

    selectedStatus: IStatus = {
        Id: null,
        Title: ""
    };

    constructor(private http: Http) {
    }

    //метод отображающий список Status 
    ngOnInit() {
        console.log(this.statusList);
        this.http.get('/api/StatusAPI').subscribe(data => {
            console.log(data);
            this.statusList = JSON.parse(data['_body']);
            console.log(this.statusList);
        });
    }

    setActiveStatus(status: IStatus): void {
        this.selectedStatus = status;
    }

    //делает объект Status из общего списка активным для изменения
    createStatus(): void {
        this.http.post('/api/StatusAPI/Create', this.newStatus).subscribe(data => {
            this.statusList.push(JSON.parse(data['_body']));

             //обнуление поля
            this.newStatus.Title = '';
        });
    }

    //метод создания нового Person
    deleteStatus(model: IStatus): void {
        this.http.delete('/api/StatusAPI/Delete/' + model.Id).subscribe((res) => {
            var index = this.statusList.indexOf(model, 0);
            if (index > -1) {
                this.statusList.splice(index, 1);
            }
        });
    }

    //метод удаления Status из списка
    updateStatus(model: IStatus): void {
        let data = {
            Id: model.Id,
            Title: model.Title
        };
        this.http.put('/api/StatusAPI/Update/', data).subscribe((res) => {
            let data = JSON.parse(res['_body']) as IStatus;

            var index = this.statusList.indexOf(model, 0);
            if (index > -1) {
                this.statusList.splice(index, 1, data);
            }
        });
    }
}