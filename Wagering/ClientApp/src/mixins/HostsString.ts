export default {
    data() {
        return {
            cutoff: 4,
        };
    },
    methods: {
        hostsString(hosts) {
            if (hosts == null) return null;
            const length = hosts.length;
            if (length > this.cutoff) {
                return (
                    hosts
                        .splice(0, this.cutoff)
                        .map((x) => x.user.userName)
                        .join(", ") +
                    ", +" +
                    (length - this.cutoff + 1) +
                    " more..."
                );
            }
            return hosts.map((x) => (x = x.user.userName)).join(", ");
        },
    },
};
