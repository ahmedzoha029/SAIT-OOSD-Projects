/**
 * DATE: Nov 19, 2019
 * COURSE: CPRG-210-OSD
 * ASSIGNMENT: THREADED PROJECT - TERM 1
 * @author: Brian Appleton
 * @description: for creating typing effects and cursor blinking effects
 */

/**
 * 
 * @param {String} id the id of the element to change
 * @param {String} text to be inserted into the element
 * @param {String} milliseconds ms between displaying the next character in the given string
 * @param {String} mirrorID is a second id which to type to
 * @param {Function} callback is a method that is called when the function has completed displaying the text parameter
 * @param {Function} callback2 a 2nd callback method
 * 
 * @description a string is displayed on the screen one charactor at a time with a defined interval between updates which creates a typing effect
 */
function textTyping(id, text, milliseconds, callback, callback2) {
    var intervalCounter = 0;

    var timer = setInterval(() => {
        if (intervalCounter < text.length) {
            document.getElementById(id).innerHTML += text.charAt(intervalCounter);
            intervalCounter++;
        }
        else {
            if (callback != undefined) {
                callback();
                if (callback2 != undefined) {
                    callback2();
                }
            }
            clearInterval(timer);
        }
    }, milliseconds);
}
/**
 * 
 * @param {String} id the id of the element where the blinking cursor will appear
 * @param {String} runTime length of time in milliseconds the function lasts
 * @param {Function} callback
 * @description creates a blinking cursor effect on a given element for a specified time period in milliseconds
 */
function blinkingCursor(id, runTime, callback) {
    var localMilliseconds = 400;
    var millisecondsPassed = 0;
    

    var timer = setInterval(() => {
        millisecondsPassed += localMilliseconds;
        var text = document.getElementById(id).innerHTML;
        var length = text.length - 1;

        //current interval is the last, stop the timer and set string field to BLANK
        if (millisecondsPassed > runTime) {
            document.getElementById(id).innerHTML = text.substring(0, length);
            clearInterval(timer);
            if (callback != undefined) {
                callback();
            }
        } 
        else if (text.endsWith("|")) {
            document.getElementById(id).innerHTML = text.substring(0, length) + ' ';
        } 
        else if (text.endsWith(' ')) {
            document.getElementById(id).innerHTML = text.substring(0, length) + "|";
        } 
        else {
            document.getElementById(id).innerHTML = text.substring(0, length + 1) + "|";
        }
    }, localMilliseconds);
}


