starterServices.factory('eventFactory', ['$resource', 'config',
    function ($resource, config) {
      return $resource(config.baseServiceURL + '/v1/events', {}, {
        getAllEvents: {
          method: 'GET',
          isArray: true
        },
        getEvent: {
          method: 'GET',
          url: config.baseServiceURL + '/v1/event'
        }
      });
    }
]);
