"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var TodoComponent = (function () {
    function TodoComponent(http) {
        this.http = http;
        this.problemList = [];
        this.statusList = [];
        this.personList = [];
        this.newProblem = {
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
        this.selectedProblem = {
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
    }
    //метод отображающий список Problem
    TodoComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.http.get('/api/ProblemAPI').subscribe(function (data) {
            _this.problemList = JSON.parse(data['_body']);
        });
        this.http.get('/api/StatusAPI').subscribe(function (data) {
            _this.statusList = JSON.parse(data['_body']);
        });
        this.http.get('/api/PersonAPI').subscribe(function (data) {
            _this.personList = JSON.parse(data['_body']);
        });
    };
    //делает объект Problem из общего списка активным для изменения
    TodoComponent.prototype.setActiveProblem = function (problem) {
        this.selectedProblem = problem;
    };
    TodoComponent.prototype.createProblem = function () {
        var _this = this;
        this.http.post('/api/ProblemAPI/Create', this.newProblem).subscribe(function (data) {
            _this.problemList.push(JSON.parse(data['_body']));
            //обнуление полей
            _this.newProblem.Name = '';
            _this.newProblem.Description = '';
            _this.newProblem.Status = null;
            _this.newProblem.Person = null;
        });
    };
    //метод создания нового Problem
    TodoComponent.prototype.deleteProblem = function (model) {
        var _this = this;
        this.http.delete('/api/ProblemAPI/Delete/' + model.Id).subscribe(function (res) {
            var index = _this.problemList.indexOf(model, 0);
            if (index > -1) {
                _this.problemList.splice(index, 1);
            }
        });
    };
    //метод удаления Problem из списка
    TodoComponent.prototype.updateProblem = function (model) {
        var _this = this;
        var data = {
            Id: model.Id,
            Name: model.Name,
            Description: model.Description,
            StatusId: model.Status.Id,
            PersonId: model.Person.Id
        };
        this.http.put('/api/ProblemAPI/Update/', data).subscribe(function (res) {
            var data = JSON.parse(res['_body']);
            var index = _this.problemList.indexOf(model, 0);
            if (index > -1) {
                _this.problemList.splice(index, 1, data);
            }
        });
    };
    return TodoComponent;
}());
TodoComponent = __decorate([
    core_1.Component({
        selector: 'todo-list',
        templateUrl: '/app/templates/todo-list.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], TodoComponent);
exports.TodoComponent = TodoComponent;
//# sourceMappingURL=todo.component.js.map