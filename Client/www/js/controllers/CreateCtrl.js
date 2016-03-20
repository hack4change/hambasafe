starterControllers.controller('CreateCtrl', function ($scope, EventFactory) {
  //init
  (function () {
    $scope.shownGroup = null;
    $scope.options = {};
  })()


  $scope.searchEvents = function () {

    EventFactory.create(
      {id: 1},
      function (event) {
        $scope.eventData = event;
      },
      function (error) {

      });
  }
  $scope.eventType = ["Walk", "Run", "Cycle"]; //convert to array of objects
  $scope.typeSelected = $scope.eventType[0];
  $scope.create = function () {

  }

  $scope.toggleGroup = function (group) {
    if ($scope.isGroupShown(group)) {
      $scope.shownGroup = null;
    } else {
      $scope.shownGroup = group;
    }
  };
  $scope.toggleSelection = function (selected, group) {
    $scope.typeSelected = selected;
    $scope.toggleGroup(group);
  };

  $scope.isGroupShown = function (type, group) {
    return $scope.shownGroup === group && $scope.typeSelected !== type;
  };

  $scope.isShown = function (type, group) {
    return $scope.shownGroup === group && $scope.typeSelected !== type;
  };

  $scope.create = function () {
    console.log(this.details);
    console.log(this.result);
    generateLocationFromAutoComplete(this.details);
  }

  function generateLocationFromAutoComplete(details) {
    var location = {};
    location.Address = details.formatted_address;
    location.Suburb = extractSuburb(details.address_components);
    location.City = extractCity(details.address_components);
    location.Province = extractProvince(details.address_components);
    location.Country = extractCountry(details.address_components);
    location.Latitude = details.geometry.location.lat();
    location.Longtitude = details.geometry.location.lng();
    console.log(location);
    return location;
  }

  function extractSuburb(results) {
    var suburbResults;
    suburbResults = findType('sublocality_level_2', results);
    if (suburbResults && suburbResults.length && suburbResults.length > 0)
      return suburbResults[0].long_name;

    suburbResults = findType('sublocality_level_1', results);
    if (suburbResults && suburbResults.length && suburbResults.length > 0)
      return suburbResults[0].long_name;

    suburbResults = findType('sublocality', results);
    if (suburbResults && suburbResults.length && suburbResults.length > 0)
      return suburbResults[0].long_name;

    return null;
  }

  function extractCity(results) {
    var suburbResults;
    suburbResults = findType('locality', results);
    if (suburbResults && suburbResults.length > 0)
      return suburbResults[0].long_name;

    return null;
  }

  function extractProvince(results) {
    var suburbResults;
    suburbResults = findType('administrative_area_level_1', results);
    if (suburbResults && suburbResults.length && suburbResults.length > 0)
      return suburbResults[0].long_name;

    return null;
  }

  function extractCountry(results) {
    var suburbResults;
    suburbResults = findType('country', results);
    if (suburbResults && suburbResults.length && suburbResults.length > 0)
      return suburbResults[0].long_name;

    return null;
  }

  function findType(type, addressComponents) {
    var results = [];

    if(!addressComponents) {
      return results;
    }

    var i = 0;
    for (i = 0; i < addressComponents.length; i++) {
      var addressComponent = addressComponents[i];
      if (addressComponent != null && addressComponent.types != null) {
        var j = 0;
        for (j = 0; j < addressComponent.types.length; j++) {
          var localType = addressComponent.types[j];
          console.log("local type: " + localType + " - " + addressComponent.long_name);
          if (type == localType) {
            results.push(addressComponent);
          }
        }
      }

    }
    return results;
  }
});
