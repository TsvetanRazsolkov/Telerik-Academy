function solve(){
  return function(){
      $.fn.listview = function (collection) {
          var templateId = '#' + this.attr('data-template'),
              templateHTML = $(templateId).html(),
              template = handlebars.compile(templateHTML),
              i,
              len = collection.length;

          for (i = 0; i < len; i += 1) {
              this.append(template(collection[i]));
          }

          return this;
    };
  };
}

module.exports = solve;