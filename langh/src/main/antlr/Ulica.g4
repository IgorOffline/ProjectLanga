grammar Ulica;
ulicaprogramid      : 'PROGRAM ID ' VARNAME ;
ulicavar            : VARNAME ;
ulicaint            : INT ;
ulicadeclaredefault : 'DEKLARIRAJ BIGINT' VARNAME ;
ulicadeclare        : 'DEKLARIRAJ BIGINT' VARNAME '=' INT ;
ulicaprint          : 'ISPISI' VARNAME ;
ulicasepint         : (', ' ulicaint)+ ;
ulicaaddition       : ulicavar ', += ' ulicasepint ;
ulicasubtraction    : ulicavar ', -= ' ulicasepint ;
ulicamain           : ulicaprogramid (ulicadeclaredefault |
                      ulicadeclare |
                      ulicaprint |
                      ulicaaddition |
                      ulicasubtraction)* ;
INT                 : [0-9]+ ;
VARNAME             : [a-zA-Z0-9\-_]+ ;
WS                  : [ \t\r\n]+ -> skip ;