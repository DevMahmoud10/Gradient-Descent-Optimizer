
x = 1:0.1:5;
%fx = 3*x+ 5 + 0.5*randn(1,length(x));

fx = 5*(x).^2 + 4*x +5 + 5*randn(1,length(x));
scatter(x,fx);
%axis([-1 7 0 30]);
hold on;

m = length(x);
theta2 = -5;
theta1 = 21;
theta0 = -5;
ux = theta2*x.^2 + theta1*x + theta0;
plot(x,ux,'color','blue');

%plot(x,ux,'color','red');
i=1;
oldError = 0;
errorDifference = 100;
while (errorDifference > 0.01)
    
    i = i+1;
    ux = theta2*x.^2 + theta1*x + theta0;
    dervErrortheta0 = sum((ux-fx))/(m);
    dervErrortheta1 = sum((ux-fx).*(x))/(m);
    dervErrortheta2 = sum((ux-fx).*(x.^2))/(m);
    theta0 = theta0 - 0.01 * dervErrortheta0;
    theta1 = theta1 - 0.01 * dervErrortheta1;
    theta2 = theta2 - 0.01 * dervErrortheta2;
    Error = 0.5*sum((ux-fx).^2)/(m);   
    errorDifference = abs(Error - oldError);
    oldError = Error;
end
hold on;
plot(x,ux,'color','red');


