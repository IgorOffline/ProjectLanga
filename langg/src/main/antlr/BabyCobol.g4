grammar BabyCobol;
bacoheader    : LINEMARKER 'MAIN DIV.' ;
bacoprogramid : LINEMARKER 'PROGRAM ID.' PROGRAMID'.' ;
bacomain      : bacoheader bacoprogramid ;
LINEMARKER    : 'X' ;
PROGRAMID     : [a-z]+ ;
WS            : [ \t\r\n]+ -> skip ;