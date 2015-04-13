@echo off
color 0a
title Hacking FBI
echo SECURITY FLAW FOUND IN FBI DATABASE
echo CONTINUE? Y/N
set /p cont = 
of%cont% == Y goto hack
:hack
echo Hack failed
pause
echo CRITICAL ERROR
ECHO FBI BACKTRACE IN EFFECT
pause
