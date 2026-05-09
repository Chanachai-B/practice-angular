export interface UserListItem {
    id: number;
    fullName: string;
    address: string;
    dob: string;
    age: number;
}

export interface User {
    id: number;
    name: string;
    lastname: string;
    address: string;
    dob: string;
    age: number;
}

export interface CreateUserRequest {
    name: string;
    lastname: string;
    address: string;
    dob: string;
}