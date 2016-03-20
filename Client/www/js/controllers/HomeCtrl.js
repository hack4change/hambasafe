starterControllers.controller('HomeCtrl', function ($scope,  $location, eventFactory) {
    var t = eventFactory.get();

    $scope.events = [];

	console.log("hello")

    for (var i = 0; i < 50; i++) {
      var event = {label: "Test " + i};
      $scope.events.push(event)
    }

    console.log("hello")


    $scope.goCreate = function() {
    	console.log("here")
    	$location.path("create");
    }
  });
