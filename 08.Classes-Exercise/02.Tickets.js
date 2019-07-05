function solve(ticketsArgs, sortingCriteria) {
    let criterias = {
        destination: 0,
        price: 1,
        status: 2
    };

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = +price;
            this.status = status;
        }
    }

    let tickets = [];
    for (let ticket of ticketsArgs) {
        let ticketArgs = ticket.split('|');
        let currentTicket = new Ticket(ticketArgs[0], ticketArgs[1], ticketArgs[2]);
        tickets.push(currentTicket);
    }

    let orderedTickets = tickets.sort((a, b) => {
        var result = (a[sortingCriteria] < b[sortingCriteria]) ? -1 : (a[sortingCriteria] > b[sortingCriteria]) ? 1 : 0;
        return result;
    });

    return orderedTickets;
}

solve(['Philadelphia|94.20|available'], 'status'
)