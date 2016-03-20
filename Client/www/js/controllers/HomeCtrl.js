starterControllers.controller('HomeCtrl', function ($scope, eventFactory) {
  var t = eventFactory.get();

  $scope.events = [];

  for (var i = 0; i < 50; i++) {
    var event = { label: "Test " + i };
    $scope.events.push(event)
  }
});
