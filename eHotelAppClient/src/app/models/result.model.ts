export class ResultModel<T>{
    data:any;
    errorMessage? :string[];
    isSuccessful? :boolean = true
    statusCode: number = 200;
}