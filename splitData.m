function [ trainingSet, testSet] = splitData( data, ratio) 
      if (nargin < 2)
         error('Not enough input arguments. data Name and split ratio (e.g 0.3) is needed');
      end
cv = cvpartition(size(data,1),'HoldOut',ratio);
indx = cv.test;
trainingSet = data(~indx ,:); 
testSet = data(indx ,:); 
