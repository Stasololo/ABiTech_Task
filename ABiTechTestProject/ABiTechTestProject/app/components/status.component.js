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
var StatusComponent = (function () {
    function StatusComponent(http) {
        this.http = http;
        this.statusList = [];
        this.newStatus = {
            Id: null,
            Title: ""
        };
        this.selectedStatus = {
            Id: null,
            Title: ""
        };
    }
    //метод отображающий список Status 
    StatusComponent.prototype.ngOnInit = function () {
        var _this = this;
        console.log(this.statusList);
        this.http.get('/api/StatusAPI').subscribe(function (data) {
            console.log(data);
            _this.statusList = JSON.parse(data['_body']);
            console.log(_this.statusList);
        });
    };
    StatusComponent.prototype.setActiveStatus = function (status) {
        this.selectedStatus = status;
    };
    //делает объект Status из общего списка активным для изменения
    StatusComponent.prototype.createStatus = function () {
        var _this = this;
        this.http.post('/api/StatusAPI/Create', this.newStatus).subscribe(function (data) {
            _this.statusList.push(JSON.parse(data['_body']));
            //обнуление поля
            _this.newStatus.Title = '';
        });
    };
    //метод создания нового Person
    StatusComponent.prototype.deleteStatus = function (model) {
        var _this = this;
        this.http.delete('/api/StatusAPI/Delete/' + model.Id).subscribe(function (res) {
            var index = _this.statusList.indexOf(model, 0);
            if (index > -1) {
                _this.statusList.splice(index, 1);
            }
        });
    };
    //метод удаления Status из списка
    StatusComponent.prototype.updateStatus = function (model) {
        var _this = this;
        var data = {
            Id: model.Id,
            Title: model.Title
        };
        this.http.put('/api/StatusAPI/Update/', data).subscribe(function (res) {
            var data = JSON.parse(res['_body']);
            var index = _this.statusList.indexOf(model, 0);
            if (index > -1) {
                _this.statusList.splice(index, 1, data);
            }
        });
    };
    return StatusComponent;
}());
StatusComponent = __decorate([
    core_1.Component({
        selector: 'status-list',
        templateUrl: '/app/templates/status-list.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], StatusComponent);
exports.StatusComponent = StatusComponent;
//# sourceMappingURL=status.component.js.map