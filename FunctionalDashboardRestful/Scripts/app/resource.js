'use restrict';

var apiServices = angular.module('apiServices', ['ngResource']);

apiServices.factory('Events', ['$resource', function($resource) {
    return $resource('api/TL_EventLog/:id', { start: '@start', end: '@end', sequence: '@sequence', institutionID: '@institutionID', uri: '@uri' }, {
        query: { method: 'GET', cache: true, url: 'api/TL_EventLog?start=:start&end=:end', isArray: true },
        queryOnFilesOrWs: { method: 'GET', cache: true, url: 'api/TL_EventLog?start=:start&end=:end&sequence=:sequence&institutionID=:institutionID&uri=:uri', isArray: true },
        get: { method: 'GET', cache: true, url: 'api/TL_EventLog?id=:id' }
    })
}]);

apiServices.factory('NCSInfo', ['$resource', function ($resource) {
    return $resource('api/NCSInfoes/:id', {}, {
        query: { method: 'GET', cache: true, isArray: true },
        get: { method: 'GET', cache: true, url: 'api/NCSInfoes?id=:id' }
    })
}]);

apiServices.factory('SLTTracking', ['$resource', function ($resource) {
    return $resource('api/CPGFD_SLTTracking/:id', {}, {
        query: { method: 'GET', cache: true, isArray: true },
        get: { method: 'GET', cache: true, url: 'api/CPGFD_SLTTracking?id=:id' }
    })
}]);