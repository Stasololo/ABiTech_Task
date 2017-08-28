﻿export interface IStatus{
    Id:number;
    Title:string;
}

export interface IPerson{    
    Id:number;
    FirstName:string;
    SurName:string;
    Email:string;    
}

export interface IProblem{    
    Id:number;
    Name:string;
    Description:string;
    Status:IStatus;
    Person:IPerson;
}