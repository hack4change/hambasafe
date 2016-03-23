starterServices.service('ProfileService',
function ($http, config, localStorageService, $q,Facebook) {
  var base = config.baseServiceURL + "/v1/";
  var profileKey = "profileKey";

  return {
    setProfileFromFacebook: function (profile) {
      localStorageService.set(profileKey, profile);
    },
    getAll: function (id) {
      return $http.get(base + 'users', config)
    },
    getById: function (id) {
      var val = id || localStorage.getItem(profileKey);

      return $http.get(base + 'users?username=' + val, config);

    },
    getByUsername: function (id) {
      var val = id || localStorage.getItem(profileKey);

      return $http.get(base + 'users?username=' + val, config);
    },
    get: function (id) {
      var val = id || localStorage.getItem(profileKey);

      return $http.get(base + 'user?id=' + val, config);

    },
    getProfileId: function () {

    },
    getFaceBookProfile() {
      var defer = $q.defer();

      Facebook.api('/me', function (response) {
        console.log(response);
        var prof = {
          FirstNames: response.first_name,
          LastName: response.last_name,
          Gender: response.gender
        };
        defer.resolve(prof);
      });
      return defer.promise;

    }
  };
}
);
