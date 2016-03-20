starterControllers.controller('HomeCtrl', function ($scope, EventFactory) {
    var t = EventFactory.get();

    $scope.events = [];

    for (var i = 0; i < 50; i++) {
      var event = {label: "Test " + i};
      $scope.events.push(event)
    }
  });
