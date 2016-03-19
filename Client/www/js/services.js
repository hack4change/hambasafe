var API_ROOT = location.origin+'/api/1';
angular.module('starter.services', [])


.factory('Chats', function() {
  // Might use a resource here that returns a JSON array

  // Some fake testing data
  var chats = [{
    id: 0,
    name: 'Ben Sparrow',
    lastText: 'You on your way?',
    face: 'img/ben.png'
  }, {
    id: 1,
    name: 'Max Lynx',
    lastText: 'Hey, it\'s me',
    face: 'img/max.png'
  }, {
    id: 2,
    name: 'Adam Bradleyson',
    lastText: 'I should buy a boat',
    face: 'img/adam.jpg'
  }, {
    id: 3,
    name: 'Perry Governor',
    lastText: 'Look at my mukluks!',
    face: 'img/perry.png'
  }, {
    id: 4,
    name: 'Mike Harrington',
    lastText: 'This is wicked good ice cream.',
    face: 'img/mike.png'
  }];

  return {
    all: function() {
      return chats;
    },
    remove: function(chat) {
      chats.splice(chats.indexOf(chat), 1);
    },
    get: function(chatId) {
      for (var i = 0; i < chats.length; i++) {
        if (chats[i].id === parseInt(chatId)) {
          return chats[i];
        }
      }
      return null;
    }
  };
})
.factory('Events', ['$http', '$q', function($http, $q){
  var eventList = [{
    id: 0,
  }, {
    id: 1,
  }, {
    id: 2,
  }, {
    id: 3,
  }, {
    id: 4,
  }];
  return {
    search: function(query, filter){
      var config = {
        headers : {
        
        } 
      }
      var data = {
        query   : query,
        filter  : filter
      }
      return $http.post(API_ROOT+'/event/search', data, config)
      .then(function success(response){
        return response.data;
      }, function error(response) {
        return $q.reject(response.data);
      })
    },
    join: function(eventId){
      var config = {
        headers : {
        
        } 
      }
      var data = {
        event: eventId
      }
      return $http.post(API_ROOT+'/event/join', data, config)
      .then(function success(response){
        return response.data;
      }, function error(response) {
        return $q.reject(response.data);
      })
    }
  }
}]);

