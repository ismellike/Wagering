<template>
    <v-simple-table dense>
        <table>
            <thead>
                <tr>
                    <th>
                        Description
                    </th>
                    <th>
                        Minimum Wager
                    </th>
                    <th>
                        Maximum Wager
                    </th>
                    <th>
                        Challenge Count
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        {{wager.description}}
                    </td>
                    <td>
                        {{ moneyDisplay(wager.minimumWager) }}
                    </td>
                    <td>
                        {{ moneyDisplay(wager.maximumWager) }}
                    </td>
                    <td>
                        {{ wager.challengeCount }}
                    </td>
                </tr>
            </tbody>
        </table>
    </v-simple-table>
</template>
<script>
    export default {
        props: {
            wager: {
                required: true
            }
        },
        methods: {
            moneyDisplay(num) {
                if (num == null) return "-";
                return "$" + num;
            }
        }
    };
</script>
