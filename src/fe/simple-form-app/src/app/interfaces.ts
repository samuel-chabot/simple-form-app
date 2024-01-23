export enum ApplicationArea {
  Dashboard = 0,
  Settings = 1,
  UserManagement = 2,
  Inventory = 3,
}

export interface ApplicationAreaOption {
  value: ApplicationArea;
  text: string;
}

export interface Item {
  id?: string;
  title: string;
  applicationArea: ApplicationArea;
  description: string;
  dateTime: Date | string;
  videoUrl?: string;
  dateCreated?: Date;
  resolved: boolean;
  tags: string[];
  contactEmail: string;
}
