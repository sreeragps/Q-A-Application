SELECT * FROM Stack 
SELECT StackQuestion FROM Stack
INSERT INTO Stack (StackQuestion,StackAnswer) VALUES('What is C?','Programming Language machine level')
UPDATE Stack SET StackQuestion='What is .NET' WHERE StackId = 2
DELETE FROM Stack WHERE StackId = 2 