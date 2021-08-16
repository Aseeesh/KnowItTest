import { CategoryModel } from "./category";


export class EventModel {
    id: number;
    employee_name:string;
    employee_salary:string;
    employee_age:string;
    name: string;
    title: string;
    description: string; 
    eventCategory:CategoryModel;
    eventCategoryId:number;
    createdBy:string;
    eventDate:string;
    createdAt:string;
}