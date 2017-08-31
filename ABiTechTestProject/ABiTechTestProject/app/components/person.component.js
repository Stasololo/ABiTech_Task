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
var PersonComponent = (function () {
    function PersonComponent(http) {
        this.http = http;
        this.personList = [];
        this.newPerson = {
            Id: null,
            FirstName: "",
            SurName: "",
            BirthDay: null,
            Email: ""
        };
        this.selectedPerson = {
            Id: null,
            FirstName: "",
            SurName: "",
            BirthDay: null,
            Email: ""
        };
    }
    //метод отображающий список Person
    PersonComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.http.get('/api/PersonAPI').subscribe(function (data) {
            _this.personList = JSON.parse(data['_body']);
        });
    };
    //делает объект Person из общего списка активным для изменения
    PersonComponent.prototype.setActivePerson = function (person) {
        this.selectedPerson = person;
    };
    //метод создания нового Person
    PersonComponent.prototype.createPerson = function () {
        var _this = this;
        this.http.post('/api/PersonAPI/Create', this.newPerson).subscribe(function (data) {
            _this.personList.push(JSON.parse(data['_body']));
            //обнуление полей
            _this.newPerson.FirstName = '';
            _this.newPerson.SurName = '';
            _this.newPerson.BirthDay = null;
            _this.newPerson.Email = '';
        });
    };
    //метод удаления Person из списка
    PersonComponent.prototype.deletePerson = function (model) {
        var _this = this;
        this.http.delete('/api/PersonAPI/Delete/' + model.Id).subscribe(function (res) {
            var index = _this.personList.indexOf(model, 0);
            if (index > -1) {
                _this.personList.splice(index, 1);
            }
        });
    };
    //метод изменения объекта Person
    PersonComponent.prototype.updatePerson = function (model) {
        var _this = this;
        var data = {
            Id: model.Id,
            Email: model.Email
        };
        this.http.put('/api/PersonAPI/Update/', data).subscribe(function (res) {
            var data = JSON.parse(res['_body']);
            var index = _this.personList.indexOf(model, 0);
            if (index > -1) {
                _this.personList.splice(index, 1, data);
            }
        });
    };
    return PersonComponent;
}());
PersonComponent = __decorate([
    core_1.Component({
        selector: 'person-list',
        templateUrl: '/app/templates/person-list.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], PersonComponent);
exports.PersonComponent = PersonComponent;
//# sourceMappingURL=person.component.js.map