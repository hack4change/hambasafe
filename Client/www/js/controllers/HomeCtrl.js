starterControllers.controller('HomeCtrl', function($scope, $location, EventFactory) {
  var t = EventFactory.getAllEvents();

  $scope.events = [];

  for (var i = 0; i < 50; i++) {
    var event = {
      label: "Test " + i
    };
    $scope.events.push(event)
  }

  $scope.click = function(event) {
    if (event.EventDateTimeEnd > new Date()) {
      $location.path("app/rating")
    } else {
      $location.path("app/event-detail")
    }
  }

});
