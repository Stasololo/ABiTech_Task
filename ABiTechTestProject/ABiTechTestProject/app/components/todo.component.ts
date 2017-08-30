import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { IProblem, IStatus, IPerson} from "../models/Models";


@Component({
    selector: 'todo-list',
    templateUrl: '/app/templates/todo-list.html'
})


export class TodoComponent implements OnInit {

    problemList: Array<IProblem> = [];
    statusList: Array<IStatus> = [];
    personList: Array<IPerson> = [];

    newProblem: IProblem = {
        Id: null,
        Name: "",
        Description: "",
        Status: {
            Id: null,
            Title: ""
        },
        Person: {
            Id: null,
            Email: "",
            FirstName: "",
            SurName: "",
            BirthDay: null
        }
    };

    selectedProblem: IProblem = {
        Id: null,
        Name: "",
        Description: "",
        Status: {
            Id: null,
            Title: ""
        },
        Person: {
            Id: null,
            Email: "",
            FirstName: "",
            SurName: "",
            BirthDay: null
        }
    };

    constructor(private http: Http) {
    }

    //метод отображающий список Problem
    ngOnInit() {
        this.http.get('/api/ProblemAPI').subscribe(data => {
            this.problemList = JSON.parse(data['_body']);
        });

        this.http.get('/api/StatusAPI').subscribe(data => {
            this.statusList = JSON.parse(data['_body']);
        });

        this.http.get('/api/PersonAPI').subscribe(data => {
            this.personList = JSON.parse(data['_body']);
        });
    }

    //делает объект Problem из общего списка активным для изменения
    setActiveProblem(problem: IProblem): void {
        this.selectedProblem = problem;
    }

    createProblem(): void {
        this.http.post('/api/ProblemAPI/Create', this.newProblem).subscribe(data => {
            this.problemList.push(JSON.parse(data['_body']));

            //обнуление полей
            this.newProblem.Name = '';
            this.newProblem.Description = '';
            this.newProblem.Status = null;
            this.newProblem.Person = null;
        });
    }

    //метод создания нового Problem
    deleteProblem(model: IProblem): void {
        this.http.delete('/api/ProblemAPI/Delete/' + model.Id).subscribe((res) => {
            var index = this.problemList.indexOf(model, 0);
            if (index > -1) {
                this.problemList.splice(index, 1);
            }
        });
    }

    //метод удаления Problem из списка
    updateProblem(model: IProblem): void {
        let data = {
            Id: model.Id,
            Name: model.Name,
            Description: model.Description,
            StatusId: model.Status.Id,
            PersonId: model.Person.Id
        };
        this.http.put('/api/ProblemAPI/Update/', data).subscribe((res) => {
            let data = JSON.parse(res['_body']) as IProblem;

            var index = this.problemList.indexOf(model, 0);
            if (index > -1) {
                this.problemList.splice(index, 1, data);
            }
        });
    }
}