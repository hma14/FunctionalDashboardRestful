'use restrict';

var functionalDashboardApp = angular.module('functionalDashboardApp', ['ngRoute', 'apiServices', 'dirPagination']);

functionalDashboardApp.config(function ($routeProvider) {
    $routeProvider.
    when('/',
    {
        templateUrl: 'Html/monitor.html',
        controller: 'monitorController'
    }).
    when('/files',
    {
        templateUrl: 'Html/files.html',
        controller: 'filesController'
    }).
    when('/cubicws',
    {
        templateUrl: 'Html/cubicws.html',
        controller: 'cubicwsController'
    }).
    when('/xmldetail',
    {
        templateUrl: 'Html/cubicws_xmldetail.html',
        controller: 'cubicwsController'
    }).
    when('/filedetail',
    {
        templateUrl: 'Html/file_detail.html',
        controller: 'filesController'
    }).
    when('/xmldata',
    {
        templateUrl: 'Html/xmldata.html',
        controller: 'filesController'
    }).
    when('/userdetail',
    {
        templateUrl: 'Html/user_detail.html',
        controller: 'cubicwsController'
    }).
    when('/institutionfiledetail',
    {
        templateUrl: 'Html/institution_file_detail.html',
        controller: 'filesController'
    }).
    when('/institutionwsdetail',
    {
        templateUrl: 'Html/institution_ws_detail.html',
        controller: 'cubicwsController'
    }).
    otherwise({
        redirectto: '/'
    });
});


