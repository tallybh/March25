using injection;

var s = new StringUse(new SmsPrint());

//s.Send("My message");

s.Send("My message", new SmsPrint());