import { Gender } from './gender.model';

export class Person {
  id: number;
  name: string;
  surname: string;
  gender: Gender;
  picturePath: string;
  dateBirth: Date;
  firstDayDate: Date;
  contractType: string;
  contractDueDate?: Date;
  department: string;
  vacationDays: number;
  freeDays: number;
  paidFreeDays: number;
}
