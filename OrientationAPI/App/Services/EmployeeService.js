app.service("EmployeeService", function ($http, $q, $rootScope, EmployeeRepository) {

    //const employee = function (employee) {
    //    return {
    //        "FirstName": employee.FirstName,
    //        "LastName": employee.LastName,
    //        "EmployeeStartDate": employee.EmployeeStartDate,
    //        "DepartmentId": employee.DepartmentId
    //    };
    //};

    //const createNewEmployee = (employee){
    //    EmployeeRepository.Create(employee);
    //}

    //const addNewEmployee = function (employee) {
    //    return $q((resolve, reject) => {
    //        $http.post(`http://localhost:50482/api/employees`, JSON.stringify(employee)).then(function (results) {
    //            resolve(results);
    //        }).catch(function (err) {
    //            reject("error in addEmployee in Service", err);
    //        });
    //    });
    //}


    //return { addEmployee }
});