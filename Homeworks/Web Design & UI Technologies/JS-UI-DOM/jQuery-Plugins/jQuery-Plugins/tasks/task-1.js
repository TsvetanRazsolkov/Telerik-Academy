function solve() {
    return function (selector) {
        var $dropDownDiv = $('<div></div>').addClass('dropdown-list'),
            $select = $(selector).css('display', 'none')
                                 .appendTo($dropDownDiv),
            $divCurrentOption = $('<div></div>').addClass('current')
                                           .attr('data-value', '')
                                           .html('Option 1')
                                           .on('click', function () {
                                               var $this = $(this);
                                               $this.text('Select a value');
                                               $optionsContainerDiv.css('display', '');

                                           })
                                           .appendTo($dropDownDiv),
            $optionsContainerDiv = $('<div></div>').addClass('options-container')
                                                   .css({
                                                       'position': 'absolute',
                                                       'display': 'none'
                                                   });

        $select.find('option')
               .each(function (index) {
                   var $this = $(this);
                   $('<div></div>').addClass('dropdown-item')
                        .attr('data-value', $this.val())
                        .attr('data-index', index)
                        .text($this.text())
                        .appendTo($optionsContainerDiv);
               });

        $optionsContainerDiv.on('click', '.dropdown-item', function () {
            var $this = $(this);
            $select.val($this.attr('data-value'));
            $divCurrentOption.text($this.text());
            $optionsContainerDiv.css('display', 'none');
        });   

        $dropDownDiv.append($optionsContainerDiv);

        $('body').append($dropDownDiv);
    };
}

module.exports = solve;